import React, { Component } from "react";

class Contactus extends Component {
    render() {
        if (!this.props.data) return null;

        const message = this.props.data.contactmessage;
        const street = this.props.data.address.street;
        const city = this.props.data.address.city;
        const phone = this.props.data.phone;
        const email = this.props.data.email;

        return (
            <>
                
                <div className="row mr-0 contactForm">
                <h5 className="col-12 text-center">{message}</h5>
                    <div className="col-12 col-md-6 offset-md-2">
                        <form action="" method="post" id="contactForm" name="contactForm">
                            <fieldset>
                                <div className="col-12">
                                    <label htmlFor="contactName">
                                        Họ và tên <span className="required">*</span>
                                    </label>
                                    <input
                                        type="text"
                                        defaultValue=""
                                        id="contactName"
                                        name="contactName"
                                        onChange={this.handleChange}
                                    />
                                </div>

                                <div className="col-12">
                                    <label htmlFor="contactEmail">
                                        Email <span className="required">*</span>
                                    </label>
                                    <input
                                        type="text"
                                        defaultValue=""
                                        id="contactEmail"
                                        name="contactEmail"
                                        onChange={this.handleChange}
                                    />
                                </div>

                                <div className="col-12">
                                    <label htmlFor="contactSubject">Tiêu đề</label>
                                    <input
                                        type="text"
                                        defaultValue=""
                                        id="contactSubject"
                                        name="contactSubject"
                                        onChange={this.handleChange}
                                    />
                                </div>

                                <div className="col-12">
                                    <label htmlFor="contactMessage">
                                        Lời nhắn <span className="required">*</span>
                                    </label>
                                    <textarea
                                        cols="50"
                                        rows="15"
                                        id="contactMessage"
                                        name="contactMessage"
                                    ></textarea>
                                </div>

                                <div className="col-12 text-center">
                                    <input type="submit" className="submit" defaultValue="Gửi" />
                                </div>
                            </fieldset>
                        </form>
                    </div>

                    <div className="col-12 col-md-4 text-center">
                        <p className="address">
                            {street} <br />
                            {city}<br />
                            <span>{email}</span><br />
                            <span>{phone}</span>
                        </p>
                    </div>
                </div>
            </>
        );
    }
}

export default Contactus;
