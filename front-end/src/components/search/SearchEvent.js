import React, {Component} from "react";

class SearchEvent extends Component {
    render() {
        return (
            <div className="search">
                <form action="" method="post" id="search" name="search" className="row">
                    <div className="col-12 col-md-4 ">
                        <label htmlFor="searchEvent"> Tìm kiếm sự kiện </label>
                        <input
                            type="text"
                            defaultValue=""
                            size="35"
                            id="searchEvent"
                            name="searchEvent"
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="col-12 col-md-4">
                        <label htmlFor="searchPlace">
                            Nơi diễn ra sự kiện
                        </label>
                        <input
                            type="text"
                            defaultValue=""
                            size="35"
                            id="searchPlace"
                            name="searchPlace"
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="col-12 col-md-4">
                        <label htmlFor="searchTime">Thời gian diễn ra</label>
                        <input
                            type="date"
                            defaultValue=""
                            size="35"
                            id="searchTime"
                            name="searchTime"
                            onChange={this.handleChange}
                        />
                    </div>
                </form>
            </div>
        )
    }
}

export default SearchEvent;