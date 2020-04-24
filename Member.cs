using System;
using System.Collections.Generic;

namespace SuperRent {
	public class Member {
		private String name, address, phoneNumber, id;
		private Double balance;
		private DateTime lastCheckout;
		public Member(String id, String name, String address, String phoneNumber) {
			this.id = id;
			this.name = name;
			this.address = address;
			this.phoneNumber = phoneNumber;
			this.balance = 0.0;
			this.lastCheckout = DateTime.Today;
		}
		public String getId() {
			return this.id;
		}
		public void setId(String id) {
			this.id = id;
		}
		public String getName() {
			return this.name;
		}
		public void setName(String name) {
			this.name = name;
		}
		public String getAddress() {
			return this.address;
		}
		public void setAddress(String address) {
			this.address = address;
		}
		public String getPhoneNumber() {
			return this.phoneNumber;
		}
		public void setPhoneNumber(String phoneNumber) {
			this.phoneNumber = phoneNumber;
		}
		public void setBalance(Double balance) {
			this.balance = balance;
		}
		public Double getBalance() {
			return this.balance;
		}
		public DateTime getLastCheckout() {
			return this.lastCheckout;
		}
		public void setLastCheckout(DateTime lastCheckout) {
			this.lastCheckout = lastCheckout;
		}
	}
}