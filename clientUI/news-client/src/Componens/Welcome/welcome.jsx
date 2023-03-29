import { useAuth0 } from "@auth0/auth0-react";
import React, { useContext, useEffect, useState } from "react";
import { Navigate } from "react-router-dom";
import { MyCategoryContext } from "../../Context/context";
import {
  getCategoryOfUser,
  getUserById,
  saveUser,
} from "../../services/services";
import { Navbar } from "../Navbar/navbar";
import { RouterComponent } from "../RouterComponent/routerComponent";

export const Welcome = () => {
  const { user } = useAuth0();
  const { MyCategory, setMyCategory } = useContext(MyCategoryContext);

  const initData = async () => {
    await saveUser(user.sub, user.email);
    const Categories = await getCategoryOfUser(user.sub);
    let CategoriesObject = Object.values(Categories);
    console.log(CategoriesObject);
    setMyCategory(CategoriesObject);
  };

  useEffect(() => {
    initData();
  }, []);

  useEffect(() => {
    console.log(MyCategory);
  }, [MyCategory]);

  return (
    <>
      <Navbar
        Category1={MyCategory[0]}
        Category2={MyCategory[1]}
        Category3={MyCategory[2]}

        // Category1={MyCategory.category1 || MyCategory[0]}
        // Category2={MyCategory.category2 || MyCategory[1]}
        // Category3={MyCategory.category3 || MyCategory[2]}
      />
      <RouterComponent />
    </>
  );
};

//if ((message = "ok")) return Navigate("/User/settings");

// export const Welcome = () => {
//   const { MyCategory } = useContext(MyCategoryContext);
//   useEffect(() => {}, [MyCategory]);

//   if (!MyCategory) {
//     return (
//       <>
//         <Navbar Category1={""} Category2={""} Category3={""} />
//         <RouterComponent />
//       </>
//     );
//   }

//   return (
//     <>
//       <Navbar
//         Category1={MyCategory[0] != undefined ? MyCategory[0] : ""}
//         Category2={MyCategory[1] != undefined ? MyCategory[1] : ""}
//         Category3={MyCategory[2] != undefined ? MyCategory[2] : ""}
//       />
//       {/* <Navbar Category1={""} Category2={""} Category3={""} /> */}
//       <RouterComponent />
//     </>
//   );
// };

// if (MyCategory.length > 0) {
//   return (
//     <>
//       <Navbar
//         Category1={MyCategory[0] != undefined ? MyCategory[0] : ""}
//         Category2={MyCategory[1] != undefined ? MyCategory[1] : ""}
//         Category3={MyCategory[2] != undefined ? MyCategory[2] : ""}
//       />
//       <RouterComponent />
//     </>
//   );
// } else {
//   return (
//     <>
//       <Navbar Category1="" Category2="" Category3="" />
//       <RouterComponent />
//     </>
//   );
// }
// };

// const [Category1] = useState(["", "", ""]);
// if (Categories.category1 !== "null") Category1[0] = Categories.category1;
// if (Categories.category2 !== "null") Category1[1] = Categories.category2;
// if (Categories.category3 !== "null") Category1[2] = Categories.category3;

// setCategory({
//   Category1: Categories.category1,
//   Category2: Categories.category2,
//   Category3: Categories.category3,
// });

// console.log(Category1);

// const initData = async () => {
//   const Categories = await getCategoryOfUser(user.sub);
//   console.log(Categories);
//   let CategoryObject = Object.values(Categories);
//   console.log(CategoryObject);

//   // setMyCategory(Categories);
//   // console.log(MyCategory);

//   setCategory((prevState) => ({ ...prevState, ...Categories }));
//   console.log(Category);

//   setMyCategory({ ...MyCategory, ...Category });
//   console.log(MyCategory);

//   MyCategory.Category1 = CategoryObject[0];
//   MyCategory.Category2 = CategoryObject[1];
//   MyCategory.Category3 = CategoryObject[2];
// };

// setMyCategory((prevState) => Object.assign({}, prevState, Categories));
// console.log(MyCategory);
// const [Category, setCategory] = useState({
//   Category1: "",
//   Category2: "",
//   Category3: "",
// });
