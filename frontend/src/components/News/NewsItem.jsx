import React from "react";
import "../News/NewsItem.css";

const NewsItem = ({ title, image, date, content }) => {
  const dateFormat = (date) => {
    const options = {
      year: "numeric",
      month: "long",
      day: "numeric",
      hour: "2-digit",
      minute: "2-digit",
    };
    const dateFormatted = new Date(date).toLocaleDateString("es-ES", options);
    const [datePart, timePart] = dateFormatted.split(", ");
    return `${datePart} · ${timePart}`;
  };

  const truncateContent = (text, maxLength) => {
    if (text.length <= maxLength) return text;
    return text.slice(0, maxLength) + "...";
  };

  const truncatedContent = truncateContent(content, 200);

  if (content.length > 200) {
    console.warn(
      `Content exceeds 200 characters. Truncated from ${content.length} to 200 characters.`
    );
  }

  return (
    <div className="news-item">
      <div className="news-item-image">
        <img src={image} alt={title} />
      </div>
      <div className="news-item-content">
        <p className="news-item-date">{dateFormat(date)}</p>
        <h2 className="news-item-title">{title}</h2>
        <p className="news-item-text">{truncatedContent}</p>
      </div>
    </div>
  );
};

export default NewsItem;
