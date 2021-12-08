import React, { Component } from 'react'
import { Container } from 'react-bootstrap'
import { variables } from './Variables';


export default class Employees extends Component {
    constructor(props){
        super(props);

        this.state = {
            employees: [],
            modalTitle: "",
            name: "",
            age: "",
            country: ""
        }
    }

    refreshList(){
        fetch(variables.API_URL + 'Employees/')
        .then(response => response.json())
        .then(data => {
            this.setState({employees: data});
        })
    }

    componentDidMount(){
        this.refreshList();
    }

    changeName = event => {
        this.setState({name: event.target.value});
    }

    changeAge = event => {
        this.setState({age: event.target.value});
    }

    changeCountry = event => {
        this.setState({country: event.target.value});
    }

    addClick = () => {
        this.setState({modalTitle: "Add employee",
                       name: "Somebody",
                       age: 30,
                       country: "Ukraine"});
    }

    createClick = () => {
        fetch(variables.API_URL + 'Employees/', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                name: this.state.name,
                age: this.state.age,
                country: this.state.country
            })
        })
        .then(response => response.json()
        .then(result => {
            alert(result);
            this.refreshList();
        }))
    }


    render() {
        const {
            employees,
            modalTitle,
            name,
            age,
            country
        } = this.state;

        return (
            <div>
                <button type="button" className="btn btn-dark btn-outline-primary" data-bs-toggle="modal" data-bs-target="#exampleModal" onClick={()=>this.addClick()}>Add Employee</button>
                <table className="table table-striped">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Name</th>
                            <th>Age</th>
                            <th>Country</th>
                        </tr>
                    </thead>
                    <tbody>
                        {employees.map(employee => 
                            <tr key={employee.id}>
                                <td>{employee.id}</td>
                                <td>{employee.name}</td>
                                <td>{employee.age}</td>
                                <td>{employee.country}</td>
                            </tr>)}
                    </tbody>
                </table>
                <div className="modal fade" id="exampleModal" tabIndex="-1" aria-hidden="true">
                    <div className="modal-dialog modal-lg modal-dialog-centered">
                        <div className="modal-context">
                            <div className="modal-header">
                                <h5 className="modal-title">{modalTitle}</h5>
                                <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div className="modal-body">
                                <div className="input-group mb-3">
                                    <span className="input-group-text">Name</span>
                                    <input type="text" className="form-control" value={name} onChange={this.changeName}></input>
                                    <span className="input-group-text">Age</span>
                                    <input type="number" className="form-control" value={age} onChange={this.changeAge}></input>
                                    <span className="input-group-text">Country</span>
                                    <input type="text" className="form-control" value={country} onChange={this.changeCountry}></input>
                                </div>
                                <button type="button" className="btn btn-dark btn-outline-primary">Create</button>
                            </div>
                        </div>

                    </div>

                </div>
            </div>
        )
    }
}

