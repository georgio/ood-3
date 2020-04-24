using System;
using System.Collections.Generic;

namespace SuperRent {
	public class SuperRent {
		private Catalog catalog;
		private List<Member> members;
		private List<Store> stores;
		private List<DailyLog> dailyLogs;
		private UInt64 userIdCounter, serialNumberCounter, rentalCodeCounter;
		public SuperRent() {
			this.stores = new List<Store>();
			this.dailyLogs = new List<DailyLog> { new DailyLog(DateTime.Today) };
			this.catalog = new Catalog("Default");
			this.userIdCounter = 1;
			this.rentalCodeCounter = 1;
			this.serialNumberCounter = 1;
		}
		public void newDay() {
			foreach (var rental in this.dailyLogs[-1].getRentals()) {
				if (rental.getDueDate().CompareTo(dailyLogs[-1].getDate()) <= 0) {
					Double fee = rental.getBaseFee() * Util.lateFeeModifier;
					rental.setExtraFee(rental.getExtraFee() + fee);
					rental.getMember().setBalance(rental.getMember().getBalance() - fee);
				}
			}
			addDailyLog(new DailyLog(this.dailyLogs[-1].getDate().AddDays(1.0)));
		}
		public UInt64 getUserIdCounter() {
			return this.userIdCounter;
		}
		public void setUserIdCounter(UInt64 userIdCounter) {
			this.userIdCounter = userIdCounter;
		}
		public UInt64 getSerialNumberCounter() {
			return this.serialNumberCounter;
		}
		public void setSerialNumberCounter(UInt64 serialNumberCounter) {
			this.serialNumberCounter = serialNumberCounter;
		}
		public UInt64 getRentalCodeCounter() {
			return this.rentalCodeCounter;
		}
		public void setRentalCodeCounter(UInt64 rentalCodeCounter) {
			this.rentalCodeCounter = rentalCodeCounter;
		}
		public List<Store> getStores() {
			return stores;
		}
		public void createStore() {
			this.addStore(promptStore());
		}
		public void addStore(Store store) {
			this.stores.Add(store);
		}
		public Store getStoreByName(String name) {
			foreach (var store in this.stores) {
				if (store.getName() == name) {
					return store;
				}
			}
			return null;
		}
		public void createCatalog() {
			this.setCatalog(promptCatalog());
		}
		public Catalog getCatalog() {
			return catalog;
		}
		public void setCatalog(Catalog catalog) {
			this.catalog = catalog;
		}
		public void addDailyLog(DailyLog dailyLog) {
			this.dailyLogs.Add(dailyLog);
		}
		public List<DailyLog> getDailyLogs() {
			return this.dailyLogs;
		}
		public Member getMemberById(String Id) {
			foreach (var member in this.members) {
				if (member.getId() == Id) {
					return member;
				}
			}
			return null;
		}
		public void createMember() {
			this.addMember(promptMember("id#" + userIdCounter));
			userIdCounter++;
		}
		public void addMember(Member member) {
			this.members.Add(member);
		}
		public List<Member> getMembers() {
			return this.members;
		}
		public void createRental() {
			String receipt = "Receipt\n-------------\n";
			Double total = 0.0;
			Console.WriteLine("Input Membership ID");
			String id = Console.ReadLine();
			Member member = getMemberById(id);
			if (member == null) {
				Console.WriteLine("User not found");
				return;
			} else {
				foreach (var dailylog in this.dailyLogs) {
					if (member.getLastCheckout() == DateTime.UnixEpoch) {
						break;
					} else {
						if (dailylog.getDate().CompareTo(member.getLastCheckout()) <= 0) {
							continue;
						} else {
							foreach (var rental in dailylog.getRentals()) {
								if (rental.getMember().getId() == id && rental.getExtraFee() > 0.0) {
									Console.WriteLine("Please settle your extra fee of $" + rental.getExtraFee() + "for your item: " + rental.getItem().getTitle().getName());
									Console.ReadLine();
									receipt += "Late Fee\t" + rental.getItem().getTitle().getName() + "\t$" + rental.getExtraFee() + "\n";
									total += rental.getExtraFee();
								}
							}
						}
					}
				}
				Console.WriteLine("Input Store Name");
				String storeName = Console.ReadLine();
				Store store = getStoreByName(storeName);
				if (store == null) {
					Console.WriteLine("Store not found");
					return;
				} else {
					Console.WriteLine("Input Title Name");
					String title = Console.ReadLine();
					foreach (var item in store.getItems()) {
						if (title == item.getTitle().getName() && item.isAvailable()) {
							item.setAvailable(false);
							Rental r = new Rental(item, member);
							addRental(r);
							receipt += "Rental Fee\t" + r.getItem().getTitle().getName() + "\t$" + r.getBaseFee() + "\n";
							total += r.getBaseFee();
							receipt += "-------------\nTotal:\t$" + total + "\n";
							receipt += "-------------\nThank you for shopping at SuperRent\n";
							Console.WriteLine(receipt);
							return;
						}
					}
					Console.WriteLine("Unable to find available copy of:" + title);
					return;
				}
			}
		}
		// TODO
		public void returnItem() {
		}
		public void addRental(Rental rental) {
			this.dailyLogs[-1].addRental(rental);
		}
		// Prompts
		public Catalog promptCatalog() {
			Console.WriteLine("Instanciating a new Catalog object:\n");
			Console.Write("\tName:\t");
			String name = Console.ReadLine();
			Console.WriteLine("Please review the information you have input:");
			Console.WriteLine("Store:");
			Console.WriteLine("\tName:\t" + name);
			Console.WriteLine("Input \"y\" to confirm, or any other character to start over");
			String confirmation = Console.ReadLine().ToLower();
			if (confirmation == "y") {
				return new Catalog(name);
			} else {
				return promptCatalog();
			}
		}
		public Member promptMember(String id) {
			Console.WriteLine("Instanciating a new Member object:\n");
			Console.Write("\tName:\t");
			String name = Console.ReadLine();
			Console.Write("\tAddress:\t");
			String address = Console.ReadLine();
			Console.Write("\tPhone Number:\t");
			String phone = Console.ReadLine();
			Console.WriteLine("Please review the information you have input:");
			Console.WriteLine("Store:");
			Console.WriteLine("\tName:\t" + name);
			Console.WriteLine("\tAddress:\t" + address);
			Console.WriteLine("\tPhone Number:\t" + phone);
			Console.WriteLine("Input \"y\" to confirm, or any other character to start over");
			String confirmation = Console.ReadLine().ToLower();
			if (confirmation == "y") {
				return new Member(id, name, address, phone);
			} else {
				return promptMember(id);
			}
		}
		public Item promptItem(Title title, UInt64 serialNumber) {
			Console.WriteLine("Instantiating a new Item object");
			Console.WriteLine("Please review the information you have input:");
			Console.WriteLine("Item:");
			Console.WriteLine("\tTitle Name:\t" + title.getName());
			String confirmation = Console.ReadLine().ToLower();
			if (confirmation == "y") {
				return new Item(serialNumber, title);
			} else {
				return promptItem(title, serialNumber);
			}
		}
		public Store promptStore() {
			Console.WriteLine("Instanciating a new Store object:\n");
			Console.Write("\tName:\t");
			String name = Console.ReadLine();
			Console.Write("\tLocation:\t");
			String location = Console.ReadLine();
			Console.Write("\tPhone Number:\t");
			String phone = Console.ReadLine();
			Console.Write("\tManager:\t");
			String manager = Console.ReadLine();
			Console.WriteLine("Please review the information you have input:");
			Console.WriteLine("Store:");
			Console.WriteLine("\tName:\t" + name);
			Console.WriteLine("\tLocation:\t" + location);
			Console.WriteLine("\tPhone Number:\t" + phone);
			Console.WriteLine("\tManager:\t" + manager);
			Console.WriteLine("Input \"y\" to confirm, or any other character to start over");
			String confirmation = Console.ReadLine().ToLower();
			if (confirmation == "y") {
				return new Store(name, location, phone, manager);
			} else {
				return promptStore();
			}
		}
		public TitleType promptTitleType() {
			Console.WriteLine("\tTitle Type:\nInput 1 for New Release, 2 for Promotional, or 3 for Normal:\t");
			String x = Console.ReadLine();
			if (x == "1") {
				return TitleType.NewRelease;
			} else if (x == "2") {
				return TitleType.Promotional;
			} else if (x == "3") {
				return TitleType.Normal;
			} else {
				Console.WriteLine("Invalid input, please try again.");
				return promptTitleType();
			}
		}
		public Title promptTitle(UInt64 rentalCode) {
			Console.WriteLine("Instanciating a new Title object:\n");
			Console.Write("\tName:\t");
			String name = Console.ReadLine();
			Console.Write("\tDescription:\t");
			String description = Console.ReadLine();
			TitleType type = promptTitleType();
			Console.WriteLine("Please review the information you have input:");
			Console.WriteLine("Title:");
			Console.WriteLine("\tName:\t" + name);
			Console.WriteLine("\tDescription:\t" + description);
			if (type == TitleType.NewRelease) {
				Console.WriteLine("\tTitle Type:\tNew Release");
			}
			if (type == TitleType.Promotional) {
				Console.WriteLine("\tTitle Type:\tPromotional");
			}
			if (type == TitleType.Normal) {
				Console.WriteLine("\tTile Type:\tNormal");
			}
			Console.WriteLine("Input \"y\" to confirm, or any other character to start over");
			String confirmation = Console.ReadLine().ToLower();
			if (confirmation == "y") {
				return promptContent(rentalCode, name, description, type);
			} else {
				return promptTitle(rentalCode);
			}
		}
		public Title promptContent(UInt64 rentalCode, String name, String description, TitleType type) {
			Console.WriteLine("\tContent Type:\nInput 1 for Music, 2 for Movie, or 3 for Game:\t");
			String x = Console.ReadLine();
			if (x == "1") {
				return promptMusic(rentalCode, name, description, type);
			} else if (x == "2") {
				return promptMovie(rentalCode, name, description, type);
			} else if (x == "3") {
				return promptGame(rentalCode, name, description, type);
			} else {
				Console.WriteLine("Invalid input, please try again.");
				return promptContent(rentalCode, name, description, type);
			}
		}
		public Game promptGame(UInt64 rentalCode, String name, String description, TitleType type) {
			Console.WriteLine("Instanciating a new Game object:\n");
			Console.Write("\tProducer:\t");
			String producer = Console.ReadLine();
			Console.Write("\tYear:\t");
			UInt64 year = Convert.ToUInt64(Console.ReadLine());
			Console.WriteLine("Please review the information you have input:");
			Console.WriteLine("Game:");
			Console.WriteLine("\tProducer:\t" + producer);
			Console.WriteLine("\tYear:\t" + year);
			Console.WriteLine("Input \"y\" to confirm, or any other character to start over");
			String confirmation = Console.ReadLine().ToLower();
			if (confirmation == "y") {
				return new Game(rentalCode, name, description, type,
				producer, year);
			} else {
				return promptGame(rentalCode, name, description, type);
			}
		}
		public Movie promptMovie(UInt64 rentalCode, String name, String description, TitleType type) {
			Console.WriteLine("Instanciating a new Movie object:\n");
			Console.Write("\tDirector:\t");
			String director = Console.ReadLine();
			Console.Write("\tCast:\t");
			String cast = Console.ReadLine();
			Console.Write("\tDuration:\t");
			UInt64 duration = Convert.ToUInt64(Console.ReadLine());
			Console.Write("\tYear:\t");
			UInt64 year = Convert.ToUInt64(Console.ReadLine());
			Console.WriteLine("Please review the information you have input:");
			Console.WriteLine("Movie:");
			Console.WriteLine("\tDirector:\t" + director);
			Console.WriteLine("\tCast:\t" + cast);
			Console.WriteLine("\tDuration:\t" + duration);
			Console.WriteLine("\tYear:\t" + year);
			Console.WriteLine("Input \"y\" to confirm, or any other character to start over");
			String confirmation = Console.ReadLine().ToLower();
			if (confirmation == "y") {
				return new Movie(rentalCode, name, description, type, director, duration, cast, year);
			} else {
				return promptMovie(rentalCode, name, description, type);
			}
		}
		public Music promptMusic(UInt64 rentalCode, String name, String description, TitleType type) {
			Console.WriteLine("Instanciating a new Music object:\n");
			Console.Write("\tProducer:\t");
			String producer = Console.ReadLine();
			Console.Write("\tSinger:\t");
			String singer = Console.ReadLine();
			Console.Write("\tDuration:\t");
			UInt64 duration = Convert.ToUInt64(Console.ReadLine());
			Console.Write("\tTracks:\t");
			UInt64 tracks = Convert.ToUInt64(Console.ReadLine());
			Console.WriteLine("Please review the information you have input:");
			Console.WriteLine("Music:");
			Console.WriteLine("\tProducer:\t" + producer);
			Console.WriteLine("\tSinger:\t" + singer);
			Console.WriteLine("\tDuration:\t" + duration);
			Console.WriteLine("\tTracks:\t" + tracks);
			Console.WriteLine("Input \"y\" to confirm, or any other character to start over");
			String confirmation = Console.ReadLine().ToLower();
			if (confirmation == "y") {
				return new Music(rentalCode, name, description, type,
				producer, singer, duration, tracks);
			} else {
				return promptMusic(rentalCode, name, description, type);
			}
		}
	}
}