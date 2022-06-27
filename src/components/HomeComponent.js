import React from 'react';
import CardEvent from './CardEvent';
import Search from './SearchEvent';
 
function Home(props) {
    return(
      <div className="container">
        <Search />
        <CardEvent />
      </div>
    );
}
 
export default Home; 
