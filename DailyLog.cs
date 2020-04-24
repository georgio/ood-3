using System;
using System.Collections.Generic;

namespace SuperRent {
	public class DailyLog {
		private DateTime date;
		private List<Rental> rentals;
		public DailyLog(DateTime date) {
			this.rentals = new List<Rental>();
			this.date = date;
		}
		public DateTime getDate() {
			return date;
		}
		public UInt64 getRentalCount() {
			return Convert.ToUInt64(rentals.Count);
		}
		public List<Rental> getRentals() {
			return rentals;
		}
		public void addRental(Rental r) {
			rentals.Add(r);
		}
	}
}