import React, { Component } from 'react';
import { variables } from './Variables';

export default class Trainers extends Component {
    constructor(props){
        super(props);

        this.state = {
            trainers: []
        }
    }

    refreshList(){
        fetch(variables.API_URL + 'Trainers/')
        .then(response => response.json())
        .then(data => {
            this.setState({trainers: data});
        })
    }

    componentDidMount(){
        this.refreshList();
    }

    render() {
        const {
            trainers
        } = this.state;

        return (
            <div>
                <table className="table table-striped">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Name</th>
                            <th>Type</th>
                        </tr>
                    </thead>
                    <tbody>
                        {trainers.map(trainer => 
                            <tr key={trainer.employeeId}>
                                <td>{trainer.employeeId}</td>
                                <td>{trainer.name}</td>
                                <td>{trainer.type}</td>
                            </tr>)}
                    </tbody>
                </table>
            </div>
        )
    }
}

