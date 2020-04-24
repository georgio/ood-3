using System;

namespace SuperRent {
	public class Music : Title {
		private UInt64 duration, tracks;
		private String producer, singer;

		public Music(UInt64 rentalCode, String name, String description, TitleType type,
		String producer, String singer, UInt64 duration, UInt64 tracks) {
			this.rentalCode = rentalCode;
			this.name = name;
			this.description = description;
			this.type = type;
			this.producer = producer;
			this.singer = singer;
			this.duration = duration;
			this.tracks = tracks;
		}
		public String getProducer() {
			return this.producer;
		}
		public void setProducer(String producer) {
			this.producer = producer;
		}
		public String getSinger() {
			return this.singer;
		}
		public void setSinger(String singer) {
			this.singer = singer;
		}
		public UInt64 getDuration() {
			return this.duration;
		}
		public void setDuration(UInt64 duration) {
			this.duration = duration;
		}
		public UInt64 getTracks() {
			return this.tracks;
		}
		public void setTracks(UInt64 tracks) {
			this.tracks = tracks;
		}
	}
}