import { AppContext } from './contexts/AppContext';
import Axios from "axios";
import { useEffect, useState } from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import HomePage from './pages/homePage/HomePage'
import SearchPage from './pages/searchPage/SearchPage'
import Layout from './pages/layout/Layout';
import UserDetailsPage from './pages/userDetailsPage/UserDetailsPage';

function App() {
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(false);
  const [alert, setAlert] = useState(null);
  const [show, setShow] = useState(true);
  const [showClearButton, setShowClearButton] = useState(false);
  const [user, setUser] = useState({});
  const [usersRepos, setUsersRepos] = useState([]);
  
  const searchUsers = ((keyword) => {
    setLoading(true);
    Axios
      .get(`https://api.github.com/search/users?q=${keyword}&per_page=100`)
      .then(response => {
        if (response.data.total_count > 0) {
          setUsers(response.data.items);
          setShowClearButton(true);
        } else {
          setUsers([]);
          setShow(true);
          initAlert('No result', 'warning');
          setShowClearButton(false);
        }
        setLoading(false);
      });
  });

  const getUser = ((userName) => {
    setLoading(true);
    clearUsers();
    Axios
      .get(`https://api.github.com/users/${userName}`)
      .then(response => {
        setUser(response.data);
        setLoading(false);
      });
  });
  
  const clearUsers = (() => {
    setUsers([]);
    setShowClearButton(false);
  });

  const getUsersRepos = ((userName) => {
    // setLoading(true);
    clearUsers();
    Axios
      .get(`https://api.github.com/users/${userName}/repos`)
      .then(response => {
        setUsersRepos(response.data);
        console.log(response.data);
        // setLoading(false);
      });
  });

  const initAlert = ((msg, type) => {
    setAlert({ msg, type });
    setTimeout(() => {
      setAlert(null);
    }, 1000);
  });

  return (
    <>
      <AppContext.Provider value={
        {
          alert,
          show,
          setShow,
          searchUsers,
          clearUsers,
          initAlert,
          users,
          loading,
          showClearButton,
          setShowClearButton,
          user,
          getUser,
          getUsersRepos,
          setUsersRepos,
          usersRepos
        }
      }>
        <BrowserRouter>
          <Layout />
          <Routes>
            <Route path='/' element={<HomePage />} />
            <Route
              path='/search'
              element={
                <SearchPage />} />
            <Route path='/getuser/:login' element={<UserDetailsPage />} />
          </Routes>
        </BrowserRouter>
      </AppContext.Provider>
    </>
  );
}

export default App;
