import AuthPage from "./components/loginPageComponent/authPage";
import SearchPage from "./components/searchPageComponent/searchPage";
import { BrowserRouter, Route, Routes } from 'react-router-dom';

function App() {
  return (
    <div className="App">
      <Routes>
        <Route exact path="/auth" element={<AuthPage/>}></Route>
        <Route path="/search" element={<SearchPage/>}></Route>
      </Routes>
    </div>
  );
}

export default App;
