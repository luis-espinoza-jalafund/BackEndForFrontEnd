import React, { useState, useEffect } from 'react';
import NewsItem from "../../../components/News/NewsItem";
import ComponentGrid from '../../../components/Grid/ComponentGrid';
import { getNewsByCategory } from '../../../services/ApiNews';

const TechnologyPage = () => {
  const [articles, setArticles] = useState([]);

  useEffect(() => {
    const fetchArticles = async () => {
      try {
        const data = await getNewsByCategory('technology');
        setArticles(data.sort((a, b) => new Date(b.CreationDate) - new Date(a.CreationDate)));
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

export default TechnologyPage;
