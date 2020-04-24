using System;
using System.Collections.Generic;

namespace SuperRent {
	public class Rental {
		private DateTime dueDate, rentalDate, dateReturned;
		private Member member;
		private Item item;
		private Double baseFee, extraFee;
		public Rental(Item item, Member member) {
			this.item = item;
			this.rentalDate = DateTime.Today;
			if (item.getTitle().getTitleType() == TitleType.NewRelease) {
				this.dueDate = DateTime.Today.Add(TimeSpan.FromDays(Util.newReleaseModifier));
			} else if (item.getTitle().getTitleType() == TitleType.Promotional) {
				this.dueDate = DateTime.Today.Add(TimeSpan.FromDays(Util.promotionalModifier));
			} else {
				this.dueDate = DateTime.Today.Add(TimeSpan.FromDays(Util.normalModifier));
			}
			if (item.getTitle() is Movie) {
				this.baseFee = Util.movieModifier;
			} else if (item.getTitle() is Music) {
				this.baseFee = Util.musicModifier;
			} else {
				this.baseFee = Util.gameModifier;
			}
			this.dateReturned = DateTime.UnixEpoch;
			this.extraFee = 0.0;
			this.member = member;
		}
		public DateTime getDueDate() {
			return this.dueDate;
		}
		public void setDueDate(DateTime dueDate) {
			this.dueDate = dueDate;
		}
		public DateTime getDateReturned() {
			return this.dateReturned;
		}
		public void setDateReturned(DateTime dateReturned) {
			this.dateReturned = dateReturned;
		}
		public DateTime getRentalDate() {
			return this.rentalDate;
		}
		public void setRentalDate(DateTime rentalDate) {
			this.rentalDate = rentalDate;
		}
		public void setMember(Member member) {
			this.member = member;
		}
		public Member getMember() {
			return this.member;
		}
		public void setItem(Item item) {
			this.item = item;
		}
		public Item getItem() {
			return this.item;
		}
		public Double getBaseFee() {
			return this.baseFee;
		}
		public void setBaseFee(Double baseFee) {
			this.baseFee = baseFee;
		}
		public Double getExtraFee() {
			return this.extraFee;
		}
		public void setExtraFee(Double extraFee) {
			this.extraFee = extraFee;
		}
	}
}