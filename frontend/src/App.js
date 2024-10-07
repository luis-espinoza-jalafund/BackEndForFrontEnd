import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Layout from "./components/Layout/Layout";
import Home from "./components/Home/Home";
import User from "./components/User/User";
import ClimateChangePage from "./pages/news-category/climate-change/page";
import PoliticsPage from "./pages/news-category/politics/page";
import TechnologyPage from "./pages/news-category/technology/page";
import HealthPage from "./pages/news-category/health/page";
import NewsDetail from "./pages/news-category/news-details/newsDetails";

function App() {
  return (
    <Router>
      <Routes>
        <Route
          path="/"
          element={
            <Layout>
              <Home />
            </Layout>
          }
        />
        <Route
          path="/users"
          element={
            <Layout category="Users">
              <User />
            </Layout>
          }
        />
        <Route
          path="/news/climate-change"
          element={
            <Layout category="Climate Change">
              <ClimateChangePage />
            </Layout>
          }
        />
        <Route
          path="/news/politics"
          element={
            <Layout category="Politics">
              <PoliticsPage />
            </Layout>
          }
        />
        <Route
          path="/news/technology"
          element={
            <Layout category="Technology">
              <TechnologyPage />
            </Layout>
          }
        />
        <Route
          path="/news/health"
          element={
            <Layout category="Health">
              <HealthPage />
            </Layout>
          }
        />
        <Route
          path="/users"
          element={
            <Layout category="Users">
              <User />
            </Layout>
          }
        />
        <Route
          path="/news/:id"
          element={
            <Layout category=''>
              <NewsDetail />
            </Layout>
          }
        />
      </Routes>
    </Router>
  );
}

export default App;
