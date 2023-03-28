import React, { Component } from 'react'
import posed from 'react-pose'
import AppConsumer from '../context';
import axios from 'axios';

var uniqid = require("uniqid");

const Animation = posed.div({
    visible: {
        opacity: 1,
        applyAtStart: {
            display: "block"
        }
    },
    hidden: {
        opacity: 0,
        applyAtEnd: {
            display: "none"
        }
    }
});

export class AddStudent extends Component {
    state = {
        visible: false,
        name: "",
        surName: "",
        identityNo: "",
        birthDate: ""
    }

    addUser = async (dispatch, e) => {
        e.preventDefault();
        const { name, surName, identityNo, birthDate } = this.state;
        const newUser = {
            name,
            surName,
            identityNo,
            birthDate: new Date(birthDate)
        };

        await axios.put("https://localhost:7212/api/Student/Create",newUser);
        newUser.id = uniqid();
        newUser.birthDate = newUser.birthDate.toDateString();
        this.setState({
            visible: false,
            name: "",
            surName: "",
            identityNo: "",
            birthDate: ""
        });
        
        dispatch({ type: "CREATE_STUDENT", payload: newUser })
    }

    changeVisibilty = () => {
        this.setState({
            visible: !this.state.visible
        });
    }

    changeInput = (e) => {
        this.setState({
            [e.target.name]: e.target.value
        });
    }

    render() {
        const { visible, name, surName, identityNo, birthDate } = this.state
        return (
            <AppConsumer>
                {
                    value => {
                        const { dispatch } = value;
                        return (
                            <div className='col-md-8 mb-4' style={{ marginLeft: '20px' }}>
                                <button onClick={this.changeVisibilty} className='btn btn-dark btn-block mb-2'> {visible ? "Hide Form" : "Show Form"}</button>
                                <Animation pose={visible ? "visible" : "hidden"}>
                                    <div className='card'>
                                        <div className='card-header'>
                                            <h4>Add Student Form</h4>
                                        </div>
                                        <div className='card-body'>
                                            <form onSubmit={this.addUser.bind(this, dispatch)}>
                                                <div className='form-group'>
                                                    <label htmlFor='name'>Name</label>
                                                    <input onChange={this.changeInput} value={name} type="text" name="name" placeholder='Enter a name' className='form-control'></input>
                                                </div>

                                                <div className='form-group'>
                                                    <label htmlFor='surname'>Surname</label>
                                                    <input onChange={this.changeInput} value={surName} type="text" name="surName" placeholder='Enter a Surname' className='form-control'></input>
                                                </div>

                                                <div className='form-group'>
                                                    <label htmlFor='identityNo'>Identity Number</label>
                                                    <input onChange={this.changeInput} value={identityNo} type="text" name="identityNo" placeholder='Enter Identity Number' className='form-control' maxLength="11" minLength="11"></input>
                                                </div>

                                                <div className='form-group'>
                                                    <label htmlFor='birthDate'>Birth Day</label>
                                                    <input onChange={this.changeInput} value={birthDate} type="text" name="birthDate" placeholder='Choose A Birth Day(dd/mm/yyyy)' className='form-control'></input>
                                                </div>

                                                <button type='submit' className='btn btn-danger btn-block mt-2'>Add Student</button>
                                            </form>
                                        </div>
                                    </div >
                                </Animation >
                            </div >
                        )
                    }
                }
            </AppConsumer>
        )
    }
}

export default AddStudent
