import React, { Component } from 'react';
import axios from 'axios';
import Card from './Card';
import { BASE_URL } from '../constants';
import './List.css';
//Nazwa Klasy/Komponentu musi być rozpoczęta wielką literą, z uwagi iż wszystkie znaczniki z małej są rezerwowane dla html 
export default class List extends Component{

    constructor(props){
        super(props);
        this.state = {
            name: props.listName
        };

    }

    renderCards = () => {
        return(
            this.props.cards.map((card) => <Card cardName={card.name}/>)
        );
    }

    onListNameChange = e => {
        this.setState({name: e.target.value});
    }

    saveListName = () => {
        axios.put(BASE_URL + '/list', {name: this.state.name, boardId: this.props.boardId, listId: this.props.listId})
        .then(() => {
            console.log("SUCCESS EDIT LIST!")
        }).catch((error) => {
            console.log(error);
        });
    }

    deleteList = () => {
        axios.delete(BASE_URL + '/list', {data: { boardId: this.props.boardId, listId: this.props.listId}})
        .then(() => {
            console.log("SUCCES REMOVE LIST!");
            this.props.deleteEvent(this.props.listId);
        }).catch((error) => {
            console.log(error);
        });
    }

    render(){
        return(
            <div className="col-3">
                <div className="row">
                    <input value={this.state.name} onChange={this.onListNameChange} className="form-control col-8" />
                    <button className="btn btn-success col-2" onClick={this.saveListName}>Edit</button>
                    <button className="btn btn-danger col-2 btn-block" onClick={this.deleteList}>X</button>
                </div>               
                <div className="card card-block">
                    {this.renderCards()}
                </div>
                <div>
                    <button className="btn btn-warning btn-sm">Add Card</button>
                </div>  
            </div>
            
        )
    }
}