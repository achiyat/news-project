import { useAuth0 } from "@auth0/auth0-react";
import React, { useContext, useEffect, useState } from "react";
import { MyCategoryContext } from "../../Context/context";
import {
  getCategoriesData,
  getCategoryOfUser,
  saveCategory,
} from "../../services/services";

export const Settings = () => {
  const [allCategories, setAllCategories] = useState([]);
  const [selectedCategories, setSelectedCategories] = useState([]);
  const { MyCategory, setMyCategory } = useContext(MyCategoryContext);

  const { user } = useAuth0();

  const initData = async () => {
    let categories = await getCategoriesData();
    setAllCategories(Object.values(categories));
  };

  const handleCategorySelection = (event) => {
    const category = event.target.value;
    const categoryIndex = selectedCategories.indexOf(category);

    // If the category is already selected, unselect it
    if (categoryIndex !== -1) {
      const updatedCategories = [...selectedCategories];
      updatedCategories.splice(categoryIndex, 1);
      setSelectedCategories(updatedCategories);
      setMyCategory(updatedCategories);
      saveSelectedCategories(updatedCategories);
    } else {
      // If the maximum number of categories is already selected, do nothing
      if (selectedCategories.length === 3) {
        return;
      }
      // Select the category
      const updatedCategories = [...selectedCategories, category];
      setSelectedCategories(updatedCategories);
      setMyCategory(updatedCategories);
      saveSelectedCategories(updatedCategories);
    }
  };

  const saveSelectedCategories = (categories) => {
    console.log(categories);
    console.log(selectedCategories);
    console.log(MyCategory);
    saveCategory(user.sub, {
      category1: categories[0] || "",
      category2: categories[1] || "",
      category3: categories[2] || "",
    });
  };

  const getFromServer = () => {
    const updatedCategories = [];

    if (MyCategory[0]) {
      updatedCategories.push(MyCategory[0]);
    }
    if (MyCategory[1]) {
      updatedCategories.push(MyCategory[1]);
    }
    if (MyCategory[2]) {
      updatedCategories.push(MyCategory[2]);
    }
    console.log(updatedCategories);
    setSelectedCategories(updatedCategories);
  };

  useEffect(() => {
    initData();
    getFromServer();
  }, []);

  return (
    <div className="container">
      <h1>בחר עד 3 קטגוריות</h1>
      <form>
        {allCategories.map((category) => (
          <div key={category} className="form-check">
            <input
              className="form-check-input"
              type="checkbox"
              value={category}
              id={category}
              onChange={handleCategorySelection}
              checked={selectedCategories.includes(category)}
              disabled={
                selectedCategories.length === 3 &&
                !selectedCategories.includes(category)
              }
            />
            <label className="form-check-label" htmlFor={category}>
              {category}
            </label>
          </div>
        ))}
      </form>
      <p>Selected categories: {selectedCategories.join(", ")}</p>
    </div>
  );
};

// const { category1, category2, category3 } = MyCategory;
// const updatedCategories = [];

// if (category1) {
//   updatedCategories.push(category1);
// }
// if (category2) {
//   updatedCategories.push(category2);
// }
// if (category3) {
//   updatedCategories.push(category3);
// }
// setSelectedCategories(updatedCategories);
