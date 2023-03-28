import React, { Component } from 'react'
// import posed from 'react-pose'
import AppConsumer from '../context';
import axios from 'axios';

var uniqid = require("uniqid");

// const Animation = posed.div({
//     visible: {
//         opacity: 1,
//         applyAtStart: {
//             display: "block"
//         }
//     },
//     hidden: {
//         opacity: 0,
//         applyAtEnd: {
//             display: "none"
//         }
//     }
// });

export class AddStudent extends Component {
    // state = {
    //     visible: false,
    //     name: "",
    //     surName: "",
    //     identityNo: "",
    //     birthDate: ""
    // }

    addUser = async (dispatch, name, surName, identityNo, birthDate, e) => {
        e.preventDefault();
        // const { name, surName, identityNo, birthDate } = this.state;
        const newUser = {
            name,
            surName,
            identityNo,
            birthDate: new Date(birthDate)
        };

        let response = await axios.put("https://localhost:7212/api/Student/Create", newUser);
        newUser.id = response.data.id

        dispatch({ type: "CREATE_STUDENT", payload: newUser })
        if (response.data.code == 1) {

        }
    }

    editUser = async (dispatch, name, surName, identityNo, birthDate, id, e) => {
        e.preventDefault();

        const editUser = {
            id,
            name,
            surName,
            identityNo,
            birthDate: new Date(birthDate)
        };

        let response = await axios.post("https://localhost:7212/api/Student/Update", editUser);

        if (response.data.code == 1)
            dispatch({ type: "EDITED_STUDENT", payload: editUser })

    }

    changeVisibilty = (dispatch, e) => {
        dispatch({ type: "CHANGE_VISIBILITY", payload: { isEdit: false } })
    }

    changeInput = (dispatch, e) => {
        dispatch({ type: "SET_PROPS", payload: { [e.target.name]: e.target.value } });
    }

    render() {
        // const { visible, name, surName, identityNo, birthDate, id, isEdit } = this.state
        return (
            <AppConsumer>
                {
                    value => {
                        const { dispatch, visible, name, surName, identityNo, birthDate, id, isEdit } = value;
                        return (
                            <div className='col-md-3 mb-4' style={{ margin: "auto"}}>
                                <button onClick={this.changeVisibilty.bind(this, dispatch)} className='btn btn-dark btn-block mb-2'> {visible ? "Hide Form" : "Show Form"}</button>
                                {/* <Animation pose={visible ? "visible" : "hidden"}> */}
                                <div className='card' style={visible ? null : { display: "none" }}>
                                    <div className='card-header'>
                                        <h4>{isEdit ? "Edit Student Form" : "Add Student Form"}</h4>
                                    </div>
                                    <div className='card-body'>
                                        <form onSubmit={isEdit ? this.editUser.bind(this, dispatch, name, surName, identityNo, birthDate, id) : this.addUser.bind(this, dispatch, name, surName, identityNo, birthDate)}>
                                            <div className='form-group'>
                                                <label htmlFor='name'>Name</label>
                                                <input onChange={this.changeInput.bind(this, dispatch)} value={name} type="text" name="name" placeholder='Enter a name' className='form-control'></input>
                                            </div>

                                            <div className='form-group'>
                                                <label htmlFor='surname'>Surname</label>
                                                <input onChange={this.changeInput.bind(this, dispatch)} value={surName} type="text" name="surName" placeholder='Enter a Surname' className='form-control'></input>
                                            </div>

                                            <div className='form-group'>
                                                <label htmlFor='identityNo'>Identity Number</label>
                                                <input onChange={this.changeInput.bind(this, dispatch)} value={identityNo} type="text" name="identityNo" placeholder='Enter Identity Number' className='form-control' maxLength="11" minLength="11"></input>
                                            </div>

                                            <div className='form-group'>
                                                <label htmlFor='birthDate'>Birth Day</label>
                                                <input onChange={this.changeInput.bind(this, dispatch)} value={birthDate} type="text" name="birthDate" placeholder='Choose A Birth Day(yyyy-mm-dd)' className='form-control'></input>
                                            </div>

                                            <button type='submit' className='btn btn-danger btn-block mt-2'> {isEdit ? "Edit Student" : "Add Student"}</button>
                                        </form>
                                    </div>
                                </div >
                                {/* </Animation > */}
                            </div >
                        )
                    }
                }
            </AppConsumer>
        )
    }
}

export default AddStudent
