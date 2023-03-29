import React from "react";
import { useAuth0 } from "@auth0/auth0-react";

export const Login = () => {
  const { loginWithRedirect } = useAuth0();

  return (
    <div className="d-grid gap-2 col-2 mx-auto">
      <div>
        <img
          src="https://www.albertadoctors.org/images/ama-master/feature/Stock%20photos/News.jpg"
          alt=""
        />
      </div>
      <button
        className="btn btn-primary"
        onClick={() => loginWithRedirect("http://localhost:3000")}
      >
        Log In
      </button>
    </div>
  );
};
