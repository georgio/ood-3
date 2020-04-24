using System;

namespace SuperRent {
	public class Movie : Title {
		private UInt64 duration, year;
		private String director, cast;

		public Movie(UInt64 rentalCode, String name, String description, TitleType type,
		String director, UInt64 duration, String cast, UInt64 year) {
			this.rentalCode = rentalCode;
			this.name = name;
			this.description = description;
			this.type = type;
			this.director = director;
			this.cast = cast;
			this.duration = duration;
			this.year = year;
		}

		public String getDirector() {
			return this.director;
		}
		public void setDirector(String director) {
			this.director = director;
		}
		public String getCast() {
			return this.cast;
		}
		public void setCast(String cast) {
			this.cast = cast;
		}
		public UInt64 getDuration() {
			return this.duration;
		}
		public void setDuration(UInt64 duration) {
			this.duration = duration;
		}
		public UInt64 getYear() {
			return this.year;
		}
		public void setYear(UInt64 year) {
			this.year = year;
		}
	}
}