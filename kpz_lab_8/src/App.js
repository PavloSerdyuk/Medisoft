import './App.css';
import {BrowserRouter, Route, Routes} from "react-router-dom";
import Table from "./Table";
import React from "react";
import AddTable from "./AddTable";

class App extends React.Component {
    render() {
        return (
            <div className="wrapper">
                <BrowserRouter>
                    <Routes>
                        <Route path="/" element={<Table/>}/>
                        <Route path="/add_record" element={<AddTable/>}/>
                    </Routes>
                </BrowserRouter>
            </div>
        );
    }
}

export default App;
