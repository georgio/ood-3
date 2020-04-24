using System;
using System.Collections.Generic;

namespace SuperRent {
	public class Catalog {
		private List<Title> titles;
		private String name;
		public Catalog(String name) {
			this.name = name;
			this.titles = new List<Title>();
		}
		public void setName(String name) {
			this.name = name;
		}
		public String getName() {
			return this.name;
		}
		public List<Title> getTitles() {
			return titles;
		}
		public void addTitle(Title t) {
			titles.Add(t);
		}
	}
}