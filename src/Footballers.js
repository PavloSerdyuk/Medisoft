import React, { Component } from 'react'
import { variables } from './Variables';
import axios from 'axios';

export default class Footballers extends Component {
    constructor(props){
        super(props);

        this.state = {
            footballers: []
        }
    }

    refreshList(){
        fetch(variables.API_URL + 'Footballers/')
        .then(response => response.json())
        .then(data => {
            this.setState({footballers: data});
        })
    }

    componentDidMount(){
        this.refreshList();
    }

    render() {
        const {footballers} = this.state;

        return (
            <div>
            <table className="table table-striped">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Shirt Number</th>
                        <th>Position</th>
                    </tr>
                </thead>
                <tbody>
                {footballers.map(footballer => 
                        <tr key={footballer.employeeId}>
                            <td>{footballer.employeeId}</td>
                            <td>{footballer.shirtNumber}</td>
                            <td>{footballer.position}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
    )
    }
}
