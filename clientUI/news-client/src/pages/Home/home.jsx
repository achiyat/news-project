import React, { useContext, useEffect, useState } from "react";
import { CardArticle } from "../../Componens";
import { MyCategoryContext } from "../../Context/context";
import { getAllArticlesForHome } from "../../services/services";
import "./home.css";

export const Home = () => {
  const [category, setCategory] = useState("");
  const [items, setItems] = useState([]);
  const [Article, setArticles] = useState([]);
  const { MyCategory } = useContext(MyCategoryContext);

  const initData = async () => {
    // console.log(MyCategory);
    // console.log(MyCategory[0]);
    // console.log(MyCategory[1]);
    // console.log(MyCategory[2]);
    if (MyCategory[0]) {
      let Article = await getAllArticlesForHome(
        MyCategory[0] || null,
        MyCategory[1] || null,
        MyCategory[2] || null
      );
      let ArticleObject = Object.values(Article);
      console.log(ArticleObject);
      setArticles(ArticleObject);
    }
  };

  const handleClick = (category) => {
    setCategory(category);
    switch (category) {
      case "וואלה":
        // console.log('"' + Article[0].link + '"');
        // console.log('"' + Article[0].nameCategory + '"');
        setItems([...Article]);
        break;
      case "מעריב":
        setItems([...Article]);
        break;
      case "ynet":
        setItems([...Article]);
        break;
      default:
        setItems([...Article]);
        break;
    }
  };

  useEffect(() => {
    initData();
  }, [MyCategory]);

  return (
    <div className="container">
      <div className="row mt-5">
        <div className="col">
          <button
            className="btn btn-primary me-3"
            onClick={() => handleClick("וואלה")}
          >
            וואלה
          </button>
          <button
            className="btn btn-primary me-3"
            onClick={() => handleClick("מעריב")}
          >
            מעריב
          </button>
          <button
            className="btn btn-primary me-3"
            onClick={() => handleClick("ynet")}
          >
            ynet
          </button>
          <button
            className="btn btn-primary"
            onClick={() => handleClick("ALL")}
          >
            הכל
          </button>
        </div>
      </div>
      {category && (
        <>
          <h5 className="mt-3">{category}</h5>
          {items
            .filter((i) => i.namesource === category || category === "ALL")
            .map((i, index) => (
              <div className="row" key={index}>
                <div className="col-md-12">
                  <CardArticle
                    img={i.img}
                    title={i.title}
                    description={i.secondaryTitle}
                    link={i.link}
                    category={i.nameCategory}
                    idArticle={i.idArticle}
                  />
                </div>
              </div>
            ))}
        </>
      )}
    </div>
  );
};

// {
//   /* <Carousel /> */
// }
// {
//   /* <GridArticle /> */
// }

// (i.namesource === category || category === "ALL") &&
// i.nameCategory === MyCategory[0] &&
// i.nameCategory === MyCategory[1] &&
// i.nameCategory === MyCategory[2]
