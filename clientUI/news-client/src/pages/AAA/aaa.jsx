import React, { useState } from "react";

const categories = [
  "Category 1",
  "Category 2",
  "Category 3",
  "Category 4",
  "Category 5",
  "Category 6",
  "Category 7",
  "Category 8",
  "Category 9",
  "Category 10",
];

export const Aaa = (props) => {
  const [selectedCategories, setSelectedCategories] = useState([]);

  const handleCategorySelection = (event) => {
    const category = event.target.value;
    if (event.target.checked) {
      setSelectedCategories([...selectedCategories, category]);
    } else {
      setSelectedCategories(selectedCategories.filter((c) => c !== category));
    }
  };

  return (
    <div className="container">
      <h1>Select up to 3 categories</h1>
      <form>
        {categories.map((category) => (
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
