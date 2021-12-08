import './App.css';
import React from "react";
import {Link} from "react-router-dom";

class AddTable extends React.Component {
    constructor(props) {
        super(props);

        let recordsArray = [
            {id: "1", patientLastName: "", doctorLastName: "", date: "", priority: 0, medicalExam: ""}
        ]

        this.state = {
            records: recordsArray,
            selectedRow: 0
        };

        this.handleSubmitClick = this.handleSubmitClick.bind(this);
    };

    handleSubmitClick(e){
        let inputs = document.getElementById("addForm").elements;
        let record = {
            patientLastName: inputs[0].value,
            doctorLastName: inputs[1].value,
            date: inputs[2].value,
            priority: Number.parseInt(inputs[3].value),
            medicalExam: inputs[4].value
        };
        console.log(record);
        console.log(JSON.stringify(record));

        fetch('http://localhost:5000/SingleRecord/', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(record)
        });
    }

    render() {
        return (
            <div className="addTableRow">
                <div className="headerBlock">
                    <Link to="/">
                        <button className="but">
                            Back
                        </button>
                    </Link>
                </div>
                <div className="contentBlock">
                    <form id="addForm">
                        <label>
                            Enter the patient last name:
                            <input type="text" className="inputField" name="patientLN"/>
                        </label>
                        <label>
                            Enter the doctor last name:
                            <input type="text" className="inputField" name="doctorLN"/>
                        </label>
                        <label>
                            Enter the date of reception:
                            <input type="text" className="inputField" name="date"/>
                        </label>
                        <label>
                            Enter the priority of reception:
                            <input type="number" className="inputField" name="priority"/>
                        </label>
                        <label>
                            Enter needed medical examinations:
                            <input type="text" className="inputField" name="medExam"/>
                        </label>
                        <Link to="/">
                            <input id="addBut" type="button" value="Add record" onClick={(e)=>this.handleSubmitClick(e)}/>
                        </Link>
                    </form>
                </div>
            </div>
        );
    }
}

export default AddTable;
