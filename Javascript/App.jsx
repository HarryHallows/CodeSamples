//File Imports
import Topbar from "./components/topbar/Topbar";
import Intro from "./components/intro/Intro";
import About from "./components/about/About";
import Portfolio from "./components/portfolio/Portfolio";
import Contact from "./components/contact/Contact";
import "./app.scss";

//Functionality
import { useState } from "react";
import Menu from "./components/menu/Menu";

function App() 
{
  //Hook to control the usage of the hamburger menu button
  const [menuOpen, setMenuOpen] = useState(false)

  return (   
    <div className="app">
     <Topbar menuOpen={menuOpen} setMenuOpen={setMenuOpen}/> 
     <Menu menuOpen={menuOpen} setMenuOpen={setMenuOpen}/>
     <div className="sections">
        <Intro/>
        <About/>
        <Portfolio/>
        <Contact/>
     </div>

    </div>
     
  );
}

export default App;
