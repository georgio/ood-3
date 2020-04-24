using System;

namespace SuperRent {
	public class Game : Title {
		private UInt64 year;
		private String producer;

		public Game(UInt64 rentalCode, String name, String description, TitleType type,
		String producer, UInt64 year) {
			this.rentalCode = rentalCode;
			this.name = name;
			this.description = description;
			this.type = type;
			this.producer = producer;
			this.year = year;
		}
		public String getProducer() {
			return this.producer;
		}
		public void setProducer(String producer) {
			this.producer = producer;
		}
		public UInt64 getYear() {
			return this.year;
		}
		public void setYear(UInt64 year) {
			this.year = year;
		}
	}
}