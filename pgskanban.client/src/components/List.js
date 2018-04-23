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
            name: props.listName,
            cards: props.cards,
            cardName: ''
        };

    }

    renderCards = () => {
        return(
            this.state.cards.map((card) => <Card key={card.id} cardName={card.name}/>)
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

    onClickAddCard = () => {
        axios.post(BASE_URL + '/card', {name: this.state.cardName, listId: this.props.listId })
        .then( (response) => {
            console.log("ADD CARD!");
            this.setState(prevState => {
                return {
                    cards: [...prevState.cards, response.data]
                }
            })
        });
    }

    onCardNameChange = e => {
        this.setState({cardName: e.target.value})
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
                    <input className="form-control" onChange={this.onCardNameChange} />
                    <button className="btn btn-warning btn-sm" onClick={this.onClickAddCard} >Add Card</button>
                </div>  
            </div>
            
        )
    }
}