import React, { useContext, useEffect, useState } from "react";
import { CardArticle } from "../../Componens";
import { MyCategoryContext } from "../../Context/context";
import {
  getArticleByIdCategory,
  getArticleData,
} from "../../services/services";

export const Category3 = () => {
  const [Article, setArticles] = useState([]);
  const { MyCategory } = useContext(MyCategoryContext);

  const initData = async () => {
    let Articles = await getArticleByIdCategory(MyCategory[2]);
    let ArticlesObject = Object.values(Articles);
    setArticles(ArticlesObject);
  };

  // useEffect
  useEffect(() => {
    initData();
  }, []);

  return (
    <div className="container">
      <div className="mt-5">
        {Article.length > 0 ? (
          Article.map((a) => (
            <CardArticle
              img={a.img}
              title={a.title}
              description={a.secondaryTitle}
              link={a.link}
              nameCategory={a.NameCategory}
              category={MyCategory[2]}
              idArticle={a.idArticle}
            />
          ))
        ) : (
          <p>not found</p>
        )}
      </div>
    </div>
  );
};
