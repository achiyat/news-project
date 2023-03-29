import { useAuth0 } from "@auth0/auth0-react";
import React from "react";
import {
  updatePopularity,
  updatePopularityArticle,
} from "../../services/services";

export const CardArticle = ({
  img,
  title,
  description,
  link,
  category,
  idArticle,
}) => {
  const { user } = useAuth0();

  const handleClick = () => {
    console.log(`${category}`);
    updatePopularity(user.sub, category);
    updatePopularityArticle(idArticle);
  };

  return (
    <div className="card mb-3 max-width">
      <div className="row g-0">
        <div className="col-md-3">
          <img
            href={link}
            onClick={handleClick}
            src={img}
            className="img-fluid rounded-start"
            alt="..."
          />
        </div>
        <div className="col-md-9">
          <div className="card-body" dir="rtl">
            <h5 className="card-title" href={link} onClick={handleClick}>
              {title}
            </h5>
            <a
              className="card-text text-black text-decoration-none"
              href={link}
            >
              {description}
            </a>
            <p className="card-text">
              <small className="text-muted">Last updated 3 minutes ago</small>
            </p>
          </div>
        </div>
      </div>
    </div>
  );
};
