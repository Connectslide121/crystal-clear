// startFrontend.js
const detectPort = require("detect-port");
const { exec } = require("child_process");

// Check if the default React port 3000 is available
detectPort(3000, (err, availablePort) => {
  if (err) {
    console.error(err);
    process.exit(1);
  }

  // Use the available port found by detect-port, or the default port if it's free
  const port = availablePort;

  // Start the React app on the available port using cross-env
  exec(`cross-env PORT=${port} npm start`, (err, stdout, stderr) => {
    if (err) {
      console.error(`exec error: ${err}`);
      return;
    }
    console.log(stdout);
    console.error(stderr);
  });
});
