using System;
using System.Collections.Generic;

namespace SuperRent {
	public class Store {
		private String name, location, phone, manager;
		private List<Item> items;
		public Store(String name, String location, String phone, String manager) {
			this.items = new List<Item>();
			this.name = name;
			this.location = location;
			this.phone = phone;
			this.manager = manager;
		}
		public void setName(String name) {
			this.name = name;
		}
		public String getName() {
			return name;
		}
		public void setLocation(String location) {
			this.location = location;
		}
		public String getLocation() {
			return location;
		}
		public void setPhone(String phone) {
			this.phone = phone;
		}
		public String getPhone() {
			return phone;
		}
		public void setManager(String manager) {
			this.manager = manager;
		}
		public String getManager() {
			return manager;
		}
		public UInt64 getItemCount() {
			return Convert.ToUInt64(items.Count);
		}
		public List<Item> getItems() {
			return items;
		}
		public void addItem(Item i) {
			items.Add(i);
		}
	}
}