using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create some videos
        Video video1 = new Video("C# Basics Tutorial", "Alice", 600);
        video1.AddComment(new Comment("Bob", "Great tutorial, thanks!"));
        video1.AddComment(new Comment("Charlie", "Very helpful for beginners."));
        video1.AddComment(new Comment("Dave", "Can you explain LINQ next?"));

        Video video2 = new Video("Travel Vlog: Japan", "Eve", 1200);
        video2.AddComment(new Comment("Frank", "Amazing views!"));
        video2.AddComment(new Comment("Grace", "I want to visit now."));
        video2.AddComment(new Comment("Heidi", "Loved the food shots."));

        Video video3 = new Video("Top 10 Sci-Fi Movies", "Ivy", 900);
        video3.AddComment(new Comment("Jack", "Great list!"));
        video3.AddComment(new Comment("Kathy", "You forgot Blade Runner."));
        video3.AddComment(new Comment("Leo", "Can you do one for horror?"));
        video3.AddComment(new Comment("Mona", "Nice editing."));

        // Put the videos in a list
        List<Video> videos = new List<Video>() { video1, video2, video3 };

        // Iterate through videos and display info and comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length (seconds): {video.LengthInSeconds}");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"\t{comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine();  // Blank line between videos
        }
    }
}
