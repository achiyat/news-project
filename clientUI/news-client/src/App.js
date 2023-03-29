import "./App.css";
import { Login, Welcome } from "./Componens";
import { useAuth0 } from "@auth0/auth0-react";
import { MyCategoryContext } from "./Context/context";
import { useState } from "react";

function App() {
  const { isAuthenticated, isLoading } = useAuth0();
  const [MyCategory, setMyCategory] = useState({});
  if (isLoading) {
    return (
      <div>
        <h1>loading init auth</h1>
      </div>
    );
  } else {
    return isAuthenticated ? (
      <MyCategoryContext.Provider value={{ MyCategory, setMyCategory }}>
        <Welcome />
      </MyCategoryContext.Provider>
    ) : (
      <Login />
    );
  }
}

export default App;

// function App() {
//   const { isAuthenticated, isLoading } = useAuth0();
//   const [MyCategory = [], setMyCategory] = useState([]);
//   const [Mysave, setMysave] = useState(false);
//   if (isLoading) {
//     return (
//       <div>
//         <h1>loading init auth</h1>
//       </div>
//     );
//   } else {
//     return isAuthenticated ? (
//       <MyCategoryContext.Provider
//         value={{ MyCategory, setMyCategory, Mysave, setMysave }}
//       >
//         <Welcome />
//       </MyCategoryContext.Provider>
//     ) : (
//       <Login />
//     );
//   }
// }
