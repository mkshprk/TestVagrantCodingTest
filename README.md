# TestVagrantCodingTest



Create an in-memory store for recently played songs that can accommodate N songs per user, with a fixed initial capacity. 
This store must have the capability to store a list of song-user pairs, with each song linked to a user. It should also be able to fetch recently played songs based on the user and eliminate the least recently played songs when the store becomes full.
EXAMPLE
Illustration, when 4 different songs were played by a user & Initial capacity is 3: 
Let's assume that the user has played 3 songs - S1, S2 and S3.
The playlist would look like -> S1,S2,S3
When S4 song is played -> S2,S3,S4 
When S2 song is played -> S3,S4,S2 
When S1 song is played -> S4,S2,S1


We will be creating the software using C#

Codebase consists of 3 projects
	• RecentlyPlayedSongsStore : Business logic of the application
	• SongStore : Application which is used by end user to interact with the application
	• UnitTestProject : project consisting of tests to test the api

To Run the test
	- clone the repo
	- Navigate inside UnitTestProject directory
	- Open command prompt
	- type: dotnet test
