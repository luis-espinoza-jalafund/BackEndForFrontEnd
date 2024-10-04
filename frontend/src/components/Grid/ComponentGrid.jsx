import React, { useState, useEffect } from "react";
import Pagination from "../Pagination/Pagination";
import "../Grid/Component.css";

const ComponentGrid = ({
  items,
  ItemComponent,
  itemsPerPage = 12,
  containerClassName = "",
  gridClassName = "",
}) => {
  const [currentPage, setCurrentPage] = useState(1);
  const [paginatedItems, setPaginatedItems] = useState([]);
  const [columns, setColumns] = useState(4);

  useEffect(() => {
    const handleResize = () => {
      if (window.innerWidth <= 768) {
        setColumns(1);
      } else if (window.innerWidth <= 1024) {
        setColumns(2);
      } else {
        setColumns(4);
      }
    };

    handleResize();
    window.addEventListener("resize", handleResize);
    return () => window.removeEventListener("resize", handleResize);
  }, []);

  useEffect(() => {
    const indexOfLastItem = currentPage * itemsPerPage;
    const indexOfFirstItem = indexOfLastItem - itemsPerPage;
    setPaginatedItems(items.slice(indexOfFirstItem, indexOfLastItem));
  }, [items, currentPage, itemsPerPage]);

  const changePage = (pageNumber) => setCurrentPage(pageNumber);

  return (
    <div className={`component-grid-container ${containerClassName}`}>
      <div className={`component-grid columns-${columns} ${gridClassName}`}>
        {paginatedItems.map((item, index) => (
          <ItemComponent key={item.id || index} {...item} />
        ))}
      </div>
      <Pagination
        itemsPerPage={itemsPerPage}
        totalItems={items.length}
        currentPage={currentPage}
        changePage={changePage}
      />
    </div>
  );
};

export default ComponentGrid;
