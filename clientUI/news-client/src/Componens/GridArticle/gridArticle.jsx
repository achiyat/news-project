import React from "react";
import { CardArticle } from "../CardArticle/cardArticle";
import "./gridArticle.css";

export const GridArticle = (Category, img) => {
  return (
    <>
      <div>
        <h1>חדשות</h1>
      </div>
      <div className="flexbox-conteiner5">
        <div className="box-grid-radius grid-header">
          <CardArticle className="img-grid-small" />
        </div>
        <div className="box-grid-radius grid-sidebar">
          <CardArticle className="img-grid-small" />
        </div>
        <div className="box-grid-radius grid-footer">
          <CardArticle className="img-grid-small" />
        </div>
        <div className="grid-main">
          <img
            src="https://www.picshare.co.il/s_pictures/img66550.jpg"
            className="img-grid-big box-grid-radius"
            alt="..."
          />
        </div>
      </div>
    </>
  );
};
