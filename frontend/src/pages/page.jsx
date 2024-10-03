import React from "react";
import NewsItem from "../components/News/NewsItem";

const AllNews = () => {
  const testNews = {
    title: "Max verstappen wins the 2024 F1 championship",
    image:
      "https://static.independent.co.uk/2023/06/03/12/02-36812c1008554e1196236fc7f0a27cd0.jpg",
    date: "2024-10-03T21:25:36Z",
    content:
      "Max Verstappen has won the 2024 Formula 1 World Championship after a dramatic season finale at the Abu Dhabi Grand Prix. The Red Bull driver clinched his second title in three years after finishing",
  };

  return (
    <div>
      <NewsItem
        title={testNews.title}
        image={testNews.image}
        date={testNews.date}
        content={testNews.content}
      />
    </div>
  );
};

export default AllNews;
