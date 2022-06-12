import React, { Component } from "react";

class PageTitle extends Component {
  render() {
    if (!this.props.data) return null;
    const title = this.props.data.title;

    return (
      <>
        <div className=" col-12 col-md-4 text-center text-md-left mb-sm-0 mt-3">
          <h3 className="page-title">{title}</h3>
        </div>
      </>
    )
  }
}

export default PageTitle;