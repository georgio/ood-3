using System;
using System.Collections.Generic;

namespace SuperRent {

	public class Title {
		protected UInt64 rentalCode;
		protected String name, description;
		protected TitleType type;
		public void setRentalCode(UInt64 rentalCode) {
			this.rentalCode = rentalCode;
		}
		public UInt64 getRentalCode() {
			return this.rentalCode;
		}
		public void setName(String name) {
			this.name = name;
		}
		public String getName() {
			return this.name;
		}
		public void setDescription(String description) {
			this.description = description;
		}
		public String getdescription() {
			return this.description;
		}
		public TitleType getTitleType() {
			return this.type;
		}
		public void setType(TitleType type) {
			this.type = type;
		}
	}
	public enum TitleType {
		NewRelease,
		Promotional,
		Normal
	}
}