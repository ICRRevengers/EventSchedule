import React, { Component } from 'react';
import ReactGA from "react-ga";
import $ from "jquery";
import Header from './HeaderComponent';
import Footer from './FooterComponent';
import Home from './HomeComponent';
import { Switch, Route, Redirect } from 'react-router-dom';
import Contactus from './ContactComponent';
import PageTitle from './PageTitle';
import Aboutus from './AboutusComponent';
import Login from './LoginComponent';
import EventSlider from './EventSlider';

class Main extends Component {
  constructor(props) {
    super(props);
    this.state = {
      foo: "bar",
      basicData: {}
    };

    ReactGA.initialize("UA-110570651-1");
    ReactGA.pageview(window.location.pathname);
  }

  getbasicData() {
    $.ajax({
      url: "./basicData.json",
      dataType: "json",
      cache: false,
      success: function (data) {
        this.setState({ basicData: data });
      }.bind(this),
      error: function (xhr, status, err) {
        console.log(err);
        alert(err);
      }
    });
  }

  componentDidMount() {
    this.getbasicData();
  }

  render() {
    const HomePage = () => {
      return (
        <>
          <PageTitle data={this.state.basicData.home}/>
          <Home />
        </>
      );
    }
    const ContactPage = () => {
      return (
        <>
          <PageTitle data={this.state.basicData.contactPage}/>
          <Contactus data={this.state.basicData.main}/>
        </>
      );
    }
    const AboutusPage = () => {
      return (
        <>
          <PageTitle data={this.state.basicData.aboutus}/>
          <Aboutus/>
        </>
      );
    }

    const LoginPage = () => {
      return (
        <>
          <PageTitle data={this.state.basicData.login}/>
          <Login />
        </>
      );
    }

    return (
      <div>
        <Header />
        <EventSlider/>
        <Switch>
          <Route path='/home' component={HomePage} />
          <Route path='/aboutus' component={AboutusPage} />
          <Route path='/contactus' component={ContactPage} />
          <Route path='/login' component={LoginPage} />
          <Redirect to="/home" />
        </Switch>
        <Footer />
      </div>
    );
  }
}

export default Main;