import axios from "axios";

export const saveUser = async (id, email) => {
  try {
    let endpoint = `http://localhost:5209/api/News/User/saveUser?UserId=${id}&Email=${email}`;
    await axios.post(endpoint);
  } catch (error) {
    console.error(error);
  }
};

export const updatePopularity = async (id, Category) => {
  try {
    console.log(id, Category);
    let endpoint = `http://localhost:5209/api/News/User/UpdatePopularity?UserId=${id}&Category=${Category}`;
    await axios.put(endpoint);
  } catch (error) {
    console.error(error);
  }
};

export const updatePopularityArticle = async (id) => {
  try {
    console.log(id);
    let endpoint = `http://localhost:5209/api/News/Article/UpdatePopularityArticle/${id}`;
    await axios.put(endpoint);
  } catch (error) {
    console.error(error);
  }
};

export const saveCategory = async (id, ClassCategory) => {
  try {
    // console.log("saveCategory");
    // console.log(id, ClassCategory);
    let endpoint = `http://localhost:5209/api/News/User/SaveCategory/${id}`;
    let response = await axios.put(endpoint, ClassCategory);
    return response.data;
  } catch (error) {
    console.error(error);
  }
};

export const getCategoryOfUser = async (id) => {
  try {
    //console.log("getCategoryOfUser");
    let endpoint = `http://localhost:5209/api/News/User/GetCategoryOfUser/${id}`;
    //console.log(endpoint);
    let response = await axios.post(endpoint);
    //return response;
    return response.data;
  } catch (error) {
    console.error(error);
  }
};

export const getCategoriesData = async () => {
  try {
    let endpoint = `http://localhost:5209/api/News/Category/GetCategory`;
    let response = await axios.get(endpoint);
    return response.data;
  } catch (error) {
    console.error(error);
  }
};

export const getArticleData = async () => {
  try {
    let endpoint = `http://localhost:5209/api/News/Article/GetAllArticles`;
    let response = await axios.get(endpoint);
    return response.data;
  } catch (error) {
    console.error(error);
  }
};

export const getAllArticlesForHome = async (
  Category1,
  Category2,
  Category3
) => {
  let endpoint = `http://localhost:5209/api/News/Article/GetAllArticlesForHome?Category1=${Category1}&Category2=${Category2}&Category3=${Category3}`;
  let response = await axios.get(endpoint);
  return response.data;
};

export const getArticleByIdCategory = async (Category) => {
  try {
    console.log(Category);
    console.log("getArticleByIdCategory");
    let endpoint = `http://localhost:5209/api/News/Article/GetArticleByIdCategory/${Category}`;
    //console.log(endpoint);
    let response = await axios.get(endpoint);
    return response.data;
  } catch (error) {
    console.error(error);
  }
};

// export const getArticleData2 = async () => {
//   console.log("getArticleData");
//   let endpoint = `http://localhost:5209/api/News/Article/GetAllArticles2`;
//   console.log(endpoint);
//   let response = await axios.get(endpoint);
//   return response.data;
// };

// export const getArticleData3 = async () => {
//   console.log("getArticleData");
//   let endpoint = `http://localhost:5209/api/News/Article/GetAllArticles3`;
//   console.log(endpoint);
//   let response = await axios.get(endpoint);
//   return response.data;
// };

// export const getUserById = async (id) => {
//   console.log("getUserById");
//   let endpoint = `http://localhost:5209/api/News/User/GetUserById/${id}`;
//   console.log(endpoint);
//   let response = await axios.get(endpoint);
//   return response.data;
// };
