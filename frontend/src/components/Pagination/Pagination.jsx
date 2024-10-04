import React from "react";
import "../Pagination/Pagination.css";

const Pagination = ({ itemsPerPage, totalItems, currentPage, changePage }) => {
  const pageNumbers = Math.ceil(totalItems / itemsPerPage);

  return (
    <nav className="pagination">
      {[...Array(pageNumbers).keys()].map((number) => (
        <button
          key={number + 1}
          onClick={() => changePage(number + 1)}
          className={currentPage === number + 1 ? "active" : ""}
        >
          {number + 1}
        </button>
      ))}
    </nav>
  );
};

export default Pagination;
