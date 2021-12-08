import 'bootstrap/dist/css/bootstrap.min.css';
import logo from './logo.svg';
import './App.css';
import Employees from './Employees';
import Footballers from './Footballers';
import Trainers from './Trainers';
import  {Container, Navbar, Nav, Row, Col} from 'react-bootstrap';
import {BrowserRouter, Route, Routes, NavLink} from 'react-router-dom';

function App() {
  return (
	  <BrowserRouter>
    <div className="App container">
		<nav className="navbar navbar-expand-lg bg-dark navbar-dark">
			<ul className="navbar-nav">
				<li className="nav-item">
					<NavLink className="btn btn-dark btn-outline-primary" to="/Employees">Employees</NavLink>
				</li>
				<li className="nav-item">
					<NavLink className="btn btn-dark btn-outline-primary" to="/Footballers">Footballers</NavLink>
				</li>
				<li className="nav-item">
					<NavLink className="btn btn-dark btn-outline-primary" to="/Trainers">Trainers</NavLink>
				</li>
			</ul>
		</nav>
		<Routes>
			<Route path='/Employees' element={<Employees/>}></Route>
			<Route path='/Footballers' element={<Footballers/>}></Route>
			<Route path='/Trainers' element={<Trainers/>}></Route>
		</Routes>
	</div>
	</BrowserRouter>
  );
}

export default App;
