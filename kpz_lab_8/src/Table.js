import './App.css';
import React from "react";
import {Link} from "react-router-dom";

class Table extends React.Component {
    constructor(props) {
        super(props);

        let recordsArray = [
            {id: "1", patientLastName: "", doctorLastName: "", date: "", priority: 0, medicalExam: ""}
        ]

        this.state = {
            records: recordsArray,
            selectedRow: 0
        };

        this.handleChangeCell = this.handleChangeCell.bind(this);
        this.handleDeleteClick = this.handleDeleteClick.bind(this);
        this.handleRowClick = this.handleRowClick.bind(this);
    };

    componentDidMount() {
        let tableBody = document.getElementById('recordsTableBody');

        let allRecords;
        fetch('http://localhost:5000/AllRecords', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then((response) => {
                return response.json();
            })
            .then((data) => {
                allRecords = data.slice();

                this.setState({records: allRecords});

                let allRecordsCount = allRecords.length;
                let result = "";
                for (let i = 0; i < allRecordsCount; i++) {
                    result += "<tr id = '" + i + "'>" +
                        "<td contentEditable='true' id='" + i + ";" + 0 + "'>"
                        + allRecords[i].patientLastName + "</td>" +
                        "<td contentEditable='true' id='" + i + ";" + 1 + "'>"
                        + allRecords[i].doctorLastName + "</td>" +
                        "<td contentEditable='true' id='" + i + ";" + 2 + "'>"
                        + allRecords[i].date + "</td>" +
                        "<td class='centerText' contentEditable='true' id='" + i + ";" + 3 + "'>"
                        + allRecords[i].priority + "</td>" +
                        "<td contentEditable='true' id='" + i + ";" + 4 + "'>"
                        + allRecords[i].medicalExam + "</td>" +
                        "</tr>";
                }

                tableBody.innerHTML = result;
                for (let i = 0; i < allRecordsCount; i++) {
                    document.getElementById(i.toString())
                        .addEventListener("click", (e) => this.handleRowClick(e));
                    for (let j = 0; j < 5; j++) {
                        document.getElementById(i.toString() + ";" + j.toString())
                            .addEventListener("input", (e) => this.handleChangeCell(e));
                    }
                }
            });
    }

    handleChangeCell(e) {
        let cell = document.getElementById(e.target.id);

        let value = cell.innerText;
        let indexString = e.target.id;
        let indexes = indexString.split(";");
        let i = Number.parseInt(indexes[0]);
        let j = Number.parseInt(indexes[1]);

        const records = this.state.records.slice();
        if (j === 0) {
            records[i].patientLastName = value;
        } else if (j === 1) {
            records[i].doctorLastName = value;
        } else if (j === 2) {
            records[i].date = value;
        } else if (j === 3) {
            records[i].priority = Number.parseInt(value);
        } else if (j === 4) {
            records[i].medicalExam = value;
        }

        this.setState({records: records});

        fetch('http://localhost:5000/SingleRecord/' + records[i].id, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(records[i])
        });
        document.location.reload();
    }

    handleDeleteClick(e){
        fetch('http://localhost:5000/SingleRecord/' + this.state.records[this.state.selectedRow].id, {
            method: 'DELETE'
        });
        document.location.reload();
    }

    handleRowClick(e){
        this.setState({selectedRow: Number.parseInt(e.target.id)});
    }

    render() {
        return (
            <div className="recordsTable">
                <div className="contentBlock">
                    <table className="tables">
                        <thead>
                        <th className="increasedTd">Patient last name</th>
                        <th className="increasedTd">Doctor last name</th>
                        <th className="increasedTd">Date</th>
                        <th>Priority</th>
                        <th className="increasedTd">Medical examination</th>
                        </thead>
                        <tbody id="recordsTableBody">

                        </tbody>
                    </table>
                </div>
                <div className="crudButtons">
                    <Link to="/add_record">
                        <button className="but">
                            Add
                        </button>
                    </Link>
                    <button className="but" onClick={(e)=>this.handleDeleteClick(e)}>
                        Delete
                    </button>
                </div>
            </div>
        );
    }
}

export default Table;
