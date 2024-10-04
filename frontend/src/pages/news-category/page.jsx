import React, { useState, useEffect } from "react";
import NewsItem from "../../components/News/NewsItem";
import ComponentGrid from "../../components/Grid/ComponentGrid";

const AllNews = () => {
  const [articles, setArticles] = useState([]);

  useEffect(() => {
    const fetchArticles = async () => {
      setArticles([
        { id: 1, title: 'Article 1', image: 'url1', date: '2024-03-01', content: 'Content 1' },
        { id: 2, title: 'Article 2', image: 'url2', date: '2024-03-02', content: 'Content 2' },
        { id: 3, title: 'Article 3', image: 'url3', date: '2024-03-03', content: 'Content 3' },
        { id: 4, title: 'Article 4', image: 'url4', date: '2024-03-04', content: 'Content 4' },
        { id: 5, title: 'Article 5', image: 'url4', date: '2024-03-04', content: 'Content 4' },
        { id: 6, title: 'Article 6', image: 'url4', date: '2024-03-04', content: 'Content 4' },
        { id: 7, title: 'Article 7', image: 'url4', date: '2024-03-04', content: 'Content 4' },
        { id: 8, title: 'Article 8', image: 'url4', date: '2024-03-04', content: 'Content 4' },
        { id: 9, title: 'Article 9', image: 'url4', date: '2024-03-04', content: 'Content 4' },
        { id: 10, title: 'Article 10', image: 'url1', date: '2024-03-01', content: 'Content 1' },
        { id: 11, title: 'Article 11', image: 'url2', date: '2024-03-02', content: 'Content 2' },
        { id: 12, title: 'Article 12', image: 'url3', date: '2024-03-03', content: 'Content 3' },
        { id: 13, title: 'Article 13', image: 'url4', date: '2024-03-04', content: 'Content 4' },
        { id: 14, title: 'Article 14', image: 'url4', date: '2024-03-04', content: 'Content 4' },
        { id: 15, title: 'Article 15', image: 'url4', date: '2024-03-04', content: 'Content 4' },
        { id: 16, title: 'Article 16', image: 'url4', date: '2024-03-04', content: 'Content 4' },
        { id: 17, title: 'Article 17', image: 'url4', date: '2024-03-04', content: 'Content 4' },
        { id: 18, title: 'Article 18', image: 'url4', date: '2024-03-04', content: 'Content 4' },
        { id: 19, title: 'Article 19', image: 'url1', date: '2024-03-01', content: 'Content 1' },
        { id: 20, title: 'Article 20', image: 'url2', date: '2024-03-02', content: 'Content 2' },
        { id: 21, title: 'Article 21', image: 'url3', date: '2024-03-03', content: 'Content 3' },
        { id: 22, title: 'Article 22', image: 'url4', date: '2024-03-04', content: 'Content 4' },
        { id: 23, title: 'Article 23', image: 'url4', date: '2024-03-04', content: 'Content 4' },
        { id: 24, title: 'Article 24', image: 'url4', date: '2024-03-04', content: 'Content 4' },
        { id: 25, title: 'Article 25', image: 'url4', date: '2024-03-04', content: 'Content 4' },
        { id: 26, title: 'Article 26', image: 'url4', date: '2024-03-04', content: 'Content 4' },
        { id: 27, title: 'Article 427', image: 'url4', date: '2024-03-04', content: 'Content 4' },
      ]);
    };

    fetchArticles();
  }, []);

  return (
    <div>
      <ComponentGrid 
        items={articles} 
        ItemComponent={NewsItem} 
        itemsPerPage={12} 
        columns={4}
        containerClassName="news-grid-container"
        gridClassName="news-grid"
      />
    </div>
  );
};

export default AllNews;
