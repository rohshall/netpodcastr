netpodcastr
===========

podcast client in C#.

It reads the podcast feeds from feeds.txt and downloads them.  

It needs .NET runtime to run.
On Linux, install mono using your package manager.  

For Arch Linux, it is:  

pacman -Syu mono  


Compile:  

mcs /reference:System.Xml.Linq.dll RSSFeedReader.cs

Run:  

mono RSSFeedReader.exe 

