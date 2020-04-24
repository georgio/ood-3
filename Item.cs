using System;
using System.Collections.Generic;


namespace SuperRent {
	public class Item {
		private Title title;
		private UInt64 serialNumber;
		private bool available;
		public Item(UInt64 serialNumber, Title title) {
			this.serialNumber = serialNumber;
			this.title = title;
			this.available = true;
		}
		public void setSerialNumber(UInt64 serialNumber) {
			this.serialNumber = serialNumber;
		}
		public UInt64 getSerialNumber() {
			return serialNumber;
		}
		public void setTitle(Title title) {
			this.title = title;
		}
		public Title getTitle() {
			return title;
		}
		public bool isAvailable() {
			return available;
		}
		public void setAvailable(bool available) {
			this.available = available;
		}
	}
}