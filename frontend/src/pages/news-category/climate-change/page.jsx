import React, { useState, useEffect } from "react";
import NewsItem from "../../../components/News/NewsItem";
import ComponentGrid from "../../../components/Grid/ComponentGrid";
import { getNewsByCategory } from "../../../services/ApiNews";

const ClimateChangePage = () => {
  const [articles, setArticles] = useState([]);

  useEffect(() => {
    const fetchArticles = async () => {
      try {
        const data = await getNewsByCategory('climate-change'.toLowerCase());
        setArticles(data.sort((a, b) => new Date(b.creationDate) - new Date(a.creationDate)));
      } catch (error) {
        console.error('Error fetching news:', error);
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

export default ClimateChangePage;
