import React from "react";
import { Link } from "react-router-dom";
import { useAuth0 } from "@auth0/auth0-react";

export const Navbar = ({ Category1, Category2, Category3 }) => {
  const { logout } = useAuth0();

  return (
    <>
      <nav className="navbar navbar-expand-lg bg-light">
        <div className="container-fluid">
          <a className="navbar-brand">News</a>
          <button
            className="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarSupportedContent"
            aria-controls="navbarSupportedContent"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarSupportedContent">
            <ul className="navbar-nav me-auto mb-2 mb-lg-0">
              <li className="nav-item">
                <Link to="/" className="nav-link active">
                  Home
                </Link>
              </li>
              <li className="nav-item">
                <Link to="/User/aaa" className="nav-link active">
                  aaa
                </Link>
              </li>
              <li className="nav-item">
                <Link to="/User/settings" className="nav-link active">
                  Settings
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  to={{
                    pathname: "/User/category1",
                    state: { category: Category1 },
                  }}
                  className="nav-link active"
                >
                  {Category1}
                </Link>
              </li>
              <li className="nav-item">
                <Link to="/User/category2" className="nav-link active">
                  {Category2}
                </Link>
              </li>
              <li className="nav-item">
                <Link to="/User/category3" className="nav-link active">
                  {Category3}
                </Link>
              </li>
            </ul>
            <form className="d-flex" role="search">
              <input
                className="form-control me-2"
                type="search"
                placeholder="Search"
                aria-label="Search"
              />
              {/* margin-right: 1em; */}
              <button className="btn btn-outline-success" type="submit">
                Search
              </button>
            </form>
            <button
              className="btn btn-danger"
              onClick={() => logout({ returnTo: window.location.origin })}
            >
              Log Out
            </button>
          </div>
        </div>
      </nav>
    </>
  );
};

//If I can transfer the parameter "Category1" to the component using the link /User/category1
