import React, { Component } from "react";
import { CLUBS } from '../shared/Clubs';
import { Media } from "reactstrap";


class Aboutus extends Component {
    constructor(props) {
        super(props);
        this.state = {
            clubs: CLUBS
        };
    }

    render() {
        const menu = this.state.clubs.map((club) => {
            return (
                <div key={club.id} className="club col-12 mt-5 row mr-0 ml-0">
                    <div className="club-logo ">
                        <img src={club.image} alt={club.name} />
                    </div>
                    <div className="ml-5 club-heading">
                        <h5>{club.name}</h5>
                        <a href={club.linkfb}>{club.linkfb}</a>
                    </div>
                </div>
            );
        });

        return (
            <div className="container">
                <div className="row">
                    <Media list>
                        {menu}
                    </Media>
                </div>
            </div>
        );
    }
}
export default Aboutus;