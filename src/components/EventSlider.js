import { Carousel } from 'react-carousel-minimal';

function EventSlider() {
 const data = [
    {
      image: "assets/images/event.png",
      caption: "BTS"
    },
    {
      image: "assets/images/jobfair.jpg",
      caption: "Job fair"
    },
    {
      image: "assets/images/tedfpt.jpg",
      caption: "TED Talk"
    },
    {
      image: "assets/images/japan.jpg",
      caption: "Japan"
    },
    {
      image: "assets/images/event.png",
      caption: "BTS"
    },
    {
      image: "assets/images/jobfair.jpg",
      caption: "Job Fair"
    },
    {
      image: "assets/images/japan.jpg",
      caption: "Japan"
    },
    {
      image: "assets/images/tedfpt.jpg",
      caption: "TED Talk"
    },
    {
      image: "assets/images/jobfair.jpg",
      caption: "Job Fair"
    }
  ];

  const captionStyle = {
    fontSize: '2em',
    fontWeight: 'bold',
  }
  const slideNumberStyle = {
    fontSize: '20px',
    fontWeight: 'bold',
  }
  return (
    <>
      <div style={{ textAlign: "center" }}>
        <div style={{
          padding: "0 20px"
        }}>
          <Carousel
            data={data}
            time={2000}
            width="100%"
            height="400px"
            captionStyle={captionStyle}
            radius="10px"
            slideNumber={true}
            slideNumberStyle={slideNumberStyle}
            captionPosition="bottom"
            automatic={true}
            dots={true}
            pauseIconColor="white"
            pauseIconSize="40px"
            slideBackgroundColor="darkgrey"
            slideImageFit="cover"
            style={{
              textAlign: "center",
              maxHeight: "300px",
              margin: "20px auto",
            }}
          />
        </div>
      </div>
    </>
  );
}

export default EventSlider;