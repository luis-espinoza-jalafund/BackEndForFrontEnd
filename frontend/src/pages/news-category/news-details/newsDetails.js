import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import { getNewsById } from "../../../services/ApiNews";
import "./newsDetails.css";

const NewsDetail = () => {
  const { id } = useParams();
  const [article, setArticle] = useState(null);

  useEffect(() => {
    const fetchArticle = async () => {
      try {
        const data = await getNewsById(id);
        setArticle(data);
      } catch (error) {
        console.error("Error fetching the article:", error);
      }
    };

    fetchArticle();
  }, [id]);

  if (!article) {
    return <div>Loading...</div>;
  }

  return (
    <div className="news-detail">
      <h1>{article.title}</h1>
      <img src={article.images} alt={article.title} />
      <p>{article.content}</p>
      <small>{new Date(article.creationDate).toLocaleDateString()}</small>
    </div>
  );
};

export default NewsDetail;
