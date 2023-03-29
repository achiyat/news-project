import React, { useState } from "react";
import { Route, Routes } from "react-router-dom";
import { MyCategoryContext } from "../../Context/context";
import {
  Aaa,
  Category1,
  Category2,
  Category3,
  Home,
  Settings,
} from "../../pages";

export const RouterComponent = () => {
  return (
    <>
      <Routes>
        <Route path="/" element={<Home />}></Route>
        <Route path="/User/aaa" element={<Aaa />}></Route>
        <Route path="/User/settings" element={<Settings />}></Route>
        <Route path="/User/category1" element={<Category1 />}></Route>
        <Route path="/User/category2" element={<Category2 />}></Route>
        <Route path="/User/category3" element={<Category3 />}></Route>
        {/* <Route path="*" element={<NotFoundPage></NotFoundPage>}></Route> */}
      </Routes>
    </>
  );
};

// setMyCategory={setMyCategory}
