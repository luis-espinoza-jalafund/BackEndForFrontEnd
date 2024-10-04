import React, { useState, useEffect } from "react";
import NewsItem from "../../components/News/NewsItem";
import ComponentGrid from "../../components/Grid/ComponentGrid";
import { getAllNews } from "../../services/ApiNews";

const AllNews = () => {
  const [articles, setArticles] = useState([]);

  useEffect(() => {
    const fetchArticles = async () => {
      try {
        const data = await getAllNews();
        setArticles(data);
      } catch (error) {
        console.error("Error fetching articles:", error);
      }
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
